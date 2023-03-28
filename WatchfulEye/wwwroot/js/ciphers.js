function caesarCipher(input, num) {

    console.log(input);

    var texts = "abcdefghijklmnopqrstuvwxyz";
    var cipheredTexts = "";

    for (var i = 0; i < texts.length; i++) {
        var offset = (i + num) % texts.length;
        cipheredTexts += texts[offset];
    }

    var result = "";

    input = input.toLowerCase();
    for (var i = 0; i < input.length; i++) {
        var index = texts.indexOf(input[i]);
        result += cipheredTexts[index];
    }
    return result;
}

 function hexCipher(str) {

    var result = "";
    for (var i = 0; i < str.length; i++) {
        hex = str.charCodeAt(i).toString(16);
        result += hex + ' ';
    }

     return result;
}

function base64Cipher(str) {
    return btoa(str);
}