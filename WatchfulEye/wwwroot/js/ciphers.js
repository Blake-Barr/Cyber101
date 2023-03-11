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