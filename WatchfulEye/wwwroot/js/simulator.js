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