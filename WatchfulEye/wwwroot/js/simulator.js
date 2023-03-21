function gameSetup(data) {
    switch (data.simulatorLevelContent.gameType) {
        case 1:
            console.log("Spot game");
            setup_SpotGame(data);
            break;
        case 2:
            console.log("Email Send");
            setup_EmailSend(data);
            break;
        case 3:
            console.log("Cipher Game");
            setup_CipherGame(data);
            break;
        case 4:
            console.log("inject game");
            break;
        case 5:
            console.log("brute Game");
            setupBruteForce();
            break;
    }
}

function checkForCompletion(data) {
    switch (data.simulatorLevelContent.gameType) {
        case -1:
            $.ajax({
                type: "POST",
                url: 'https://localhost:7128/WatchfulEye/CheckCompletion/',
                data: data,
                success: function (resultData) {
                    navigateUserToCompletionPage();
                }
                //},
                //dataType: dataType
            });
            break;
        case 0:
            console.log(data);
            var answers = getQuizAnswers();
            data.answers = answers;
            if (answers != false) {
                $.ajax({
                    type: "POST",
                    url: 'https://localhost:7128/WatchfulEye/CheckCompletion/',
                    data: data,
                    success: function (resultData) {
                        console.log(resultData);
                        if (resultData.completed) {
                            navigateUserToCompletionPage();
                        } else {
                            displayIncorrects(resultData.incorrectList);
                        }
                    }
                    //},
                    //dataType: dataType
                });
            } else {
                displayError('Please answer all questions!');
            }
            break;
        case 1:
            console.log(data);
            var spotCounts = $("#spot_body .spot_item.clicked").length;
            data.spotCount = spotCounts;
            $.ajax({
                type: "POST",
                url: 'https://localhost:7128/WatchfulEye/CheckCompletion/',
                data: data,
                success: function (resultData) {
                    console.log(resultData);
                    if (resultData.completed) {
                        navigateUserToCompletionPage();
                    } else {

                    }
                }
                //},
                //dataType: dataType
            });
            break;
        case 2:
            var selectedTemp = $('.templates input:checked').val();
            data.template = selectedTemp;
            data.email = $('#email_body #targetEmail').val();
            data.name = $('#email_body #targetName').val();
            if (data.email != "" && data.name != "" && data.template != null) {
                $.ajax({
                    type: "POST",
                    url: 'https://localhost:7128/WatchfulEye/CheckCompletion/',
                    data: data,
                    success: function (resultData) {
                        navigateUserToCompletionPage();
                    }
                    //},
                    //dataType: dataType
                });
            } else {
                displayError("Please fill out both fields, and choose a template.");
            }
            break;
        case 3:
            var cipheredText = $('#encryptedInput').text();
            var encWord = $('#encryptedWord').text();

            if (cipheredText == encWord) {
                $.ajax({
                    type: "POST",
                    url: 'https://localhost:7128/WatchfulEye/CheckCompletion/',
                    data: data,
                    success: function (resultData) {
                        navigateUserToCompletionPage();
                    }
                    //},
                    //dataType: dataType
                });
            }
            console.log(cipheredText);
            console.log(encWord);
            break;
        case 4:
            var expectedHTML = $('#inject_goal').html();
            var inputHTML = $('#inject_output').html();

            if (expectedHTML == inputHTML) {
                $.ajax({
                    type: "POST",
                    url: 'https://localhost:7128/WatchfulEye/CheckCompletion/',
                    data: data,
                    success: function (resultData) {
                        navigateUserToCompletionPage();
                    }
                    //},
                    //dataType: dataType
                });
            }
            break;
        case 5:
            var res = returnResult();
            if (res.level > 1) {
                $.ajax({
                    type: "POST",
                    url: 'https://localhost:7128/WatchfulEye/CheckCompletion/',
                    data: data,
                    success: function (resultData) {
                        navigateUserToCompletionPage();
                    }
                    //},
                    //dataType: dataType
                });
            }
            break;
    }

}

function getQuizAnswers() {
    var answers = "";
    var inputs = $('#quiz_body .question');
    for (var i = 0; i < inputs.length; i++) {
        var ansList = inputs[i].querySelectorAll("input");
        for (var j = 0; j < ansList.length; j++) {
            if (ansList[j].checked) {
                answers += ansList[j].value;
            }
        }
    }

    if (inputs.length != answers.length)  {
        return false;
    }
    return answers;
}

function displayIncorrects(mismatches) {
    var questions = $('#quiz_body .question');
    questions.each(function (ind) {
        if (mismatches[ind] == "0") {
            if (!$(this).find('i').length) {
                var ansid = $(this).find('input:checked').attr('id');
                $(this).find('label#' + ansid + 'l').after('<i class="fas fa-times"></i>');
                $(this).find('label#' + ansid + 'l').addClass('WE_Incorrect');
            } 
        } else {
            if (!$(this).find('i').length) {
                var ansid = $(this).find('input:checked').attr('id');
                $(this).find('label#' + ansid + 'l').after('<i class="fas fa-check"></i>');
                $(this).find('label#' + ansid + 'l').addClass('WE_Correct');
            } 
        }
    });
}

function navigateUserToCompletionPage() {
    //Disable button
    $('#completionButton').disabled = true;
    var oldXP = $("#we_currentxp").text();
    var oldtoXP = $("#we_toxp").text();
    window.location.href = "/WatchfulEye/LevelComplete?xp=" + oldXP + "&toxp=" + oldtoXP;
}

function setup_SpotGame(data) {
    var spotObjects = $("#spot_body .spot_item");

    if (spotObjects.length > 0) {
        var spotCounter = document.createElement("div");
        var spotCounterText = document.createElement("p");
        spotCounter.id = "spot_counter";
        spotCounterText.classList.add("spotcounter");
        spotCounterText.innerText = "0/" + spotObjects.length;
        spotCounter.append(spotCounterText);
        $("#lvlInteractive").append(spotCounter);

        spotObjects.each(function () {
            $(this).click(function () {
                $(this).addClass("clicked");
                updateCounter(spotObjects.length);
            });
        });
    }

    console.log(":)");
}

function updateCounter(length) {
    $("#spot_counter .spotcounter").text($("#spot_body .spot_item.clicked").length + "/" + length);
}

function setup_EmailSend(data) {
    var data = {
        amount: 3
    };
    $.ajax({
        type: "POST",
        url: 'https://localhost:7128/WatchfulEye/GetEmailTemplates/',
        data: data,
        success: function (resultData) {
            setupPreviews(resultData);
        }
        //},
        //dataType: dataType
    });
}

function setupPreviews(temp) {
    console.log(temp);
    $(".templates #tempview1").html('<img src="/images/EmailTemplates/' + temp[0].previewPath + '">');
    $(".templates #t1").val(temp[0].id);
    $(".templates #tempview2").html('<img src="/images/EmailTemplates/' + temp[1].previewPath + '">');
    $(".templates #t2").val(temp[1].id);
    $(".templates #tempview3").html('<img src="/images/EmailTemplates/' + temp[2].previewPath + '">');
    $(".templates #t3").val(temp[2].id);
}

function setup_CipherGame(data) {
    var words = data.simulatorLevelContent.cipherList.split(',');
    var encWord = data.simulatorLevelContent.encryptedWord;

    var cipherType = data.simulatorLevelContent.cipherType;

    switch (cipherType) {
        case 0:
            $('#cypherType').text('Caesar Cipher');
            $('#cypherDesc').text('Caesar Ciphers are a simple encryption method performed by taking an alphabetical character and shifting the letter forwards by a certain amount. For example, encrypting the term \'hat\' with a shift of 3 (a \'shift\' refers to how many characters to move backwards) would return the value \'kdw\'. In this example, the shift will be 2 characters.')
            $('#cypherType').attr('data-type', 0);
            break;
    }

    for (var i = 0; i < words.length; i++) {
        var listItem = "<li><p>" + words[i] + "</p></li>";
        $('#words').append(listItem);
    }

    if (encWord) {
        $('#encryptedWord').html(encWord);
    }
    console.log(words);
}

function encryptInput() {
    var input = $('#cipherText').val();

    if (input) {
        var cipheredText = '';
        var cipherType = $('#cypherType').attr('data-type');
        switch (cipherType) {
            case "0":
                cipheredText = caesarCipher(input, 2);
                break;
        }

        $('#encryptedInput').html(cipheredText);

        var cipheredText = $('#encryptedInput').text();
        var encWord = $('#encryptedWord').text();

        if (cipheredText == encWord) {
            $('#encryptedInput').addClass("WE_Correct");
            $('#encryptedWord').addClass("WE_Correct");
        } else {
            $('#encryptedInput').addClass("WE_Incorrect");
        }
    }
}

function setup_InjectGame(data) {

}

function injectText() {
    var input = $("#injectBox").val();

    $('#inject_output').html(input);

    var injinput = $('#inject_goal').html();
    var injoutput = $('#inject_output').html();

    if (injinput == injoutput) {
        $('#injectGoal').addClass("WE_Correct");
        $('#injectoutput').addClass("WE_Correct");
    } else {
        $('#injectoutput').addClass("WE_Incorrect");
    }
}

function displayError(message) {
    $('#errorBox').css("display","block");
    $('#errorBox p').text(message);
}