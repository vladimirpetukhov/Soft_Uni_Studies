function solve() {
    let parent = document.getElementById('exercise').children;
    let encodeSent = parent[0];
    let decodeRead = parent[1];

    let encodeSentButton = encodeSent.getElementsByTagName('button')[0];
    encodeSentButton.addEventListener('click', encodeAndSent);

    let decodeReadButton = decodeRead.getElementsByTagName('button')[0];
    decodeReadButton.addEventListener('click', decodeAndRead);

    console.log(encodeSent);
    console.log(decodeRead);

    function encodeAndSent(e) {
        let encodeTextArea = encodeSent.getElementsByTagName('textarea')[0].value;
        let encodedText = '';
        for (let i = 0; i < encodeTextArea.length; i++) {
            encodedText += nextChar(encodeTextArea[i]);
        }

        encodeSent.getElementsByTagName('textarea')[0].value = '';
        decodeRead.getElementsByTagName('textarea')[0].value = encodedText;

        function nextChar(c) {
            return String.fromCharCode(c.charCodeAt(0) + 1);
        }
    }

    function decodeAndRead(e) {
        let decodeTextArea = decodeRead.getElementsByTagName('textarea')[0].value;
        let decodedText = '';
        for (let i = 0; i < decodeTextArea.length; i++) {
            decodedText += previousChar(decodeTextArea[i]);
        }

        decodeRead.getElementsByTagName('textarea')[0].value = decodedText;

        function previousChar(c) {
            return String.fromCharCode(c.charCodeAt(0) - 1);
        }
    }
}function solve() {
    let parent = document.getElementById('exercise').children;
    let encodeSent = parent[0];
    let decodeRead = parent[1];

    let encodeSentButton = encodeSent.getElementsByTagName('button')[0];
    encodeSentButton.addEventListener('click', encodeAndSent);

    let decodeReadButton = decodeRead.getElementsByTagName('button')[0];
    decodeReadButton.addEventListener('click', decodeAndRead);

    console.log(encodeSent);
    console.log(decodeRead);

    function encodeAndSent(e) {
        let encodeTextArea = encodeSent.getElementsByTagName('textarea')[0].value;
        let encodedText = '';
        for (let i = 0; i < encodeTextArea.length; i++) {
            encodedText += nextChar(encodeTextArea[i]);
        }

        encodeSent.getElementsByTagName('textarea')[0].value = '';
        decodeRead.getElementsByTagName('textarea')[0].value = encodedText;

        function nextChar(c) {
            return String.fromCharCode(c.charCodeAt(0) + 1);
        }
    }

    function decodeAndRead(e) {
        let decodeTextArea = decodeRead.getElementsByTagName('textarea')[0].value;
        let decodedText = '';
        for (let i = 0; i < decodeTextArea.length; i++) {
            decodedText += previousChar(decodeTextArea[i]);
        }

        decodeRead.getElementsByTagName('textarea')[0].value = decodedText;

        function previousChar(c) {
            return String.fromCharCode(c.charCodeAt(0) - 1);
        }
    }
}