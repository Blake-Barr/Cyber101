function gameSetup(data) {
    switch (data.simulatorLevelContent.gameType) {
        case 1:
            console.log("Spot game");
            setup_SpotGame(data);
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
                        console.log("not all clicked");
                    }
                }
                //},
                //dataType: dataType
            });
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
    return answers;
}

function displayIncorrects(mismatches) {
    var questions = $('#quiz_body .question');
    for (var i = 0; i < questions.length; i++) {
        if (mismatches[i] == "0") {
            questions[i].querySelector('p').innerHTML = 'nope';
        }
    }
}

function navigateUserToCompletionPage() {
    //Disable button
    $('#completionButton').disabled = true;
    window.location.href = "/Home/Index";
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