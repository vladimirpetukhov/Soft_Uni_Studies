function solve() {

    let selectMenuTo = document.getElementById('selectMenuTo');

    populateSelectedMenuTo(selectMenuTo);

    let convert = document.getElementById('exercise')
        .getElementsByTagName('button')[0]
        .addEventListener('click', eventClick);

    function eventClick(e) {

        let number = document.getElementById('input').value;
        let result = document.getElementById('result');

        let convertTo = Array.from(selectMenuTo.children).filter(x => x.selected)[0];
        let input = document.getElementById('input').value;
        if (convertTo.value === 'binary') {

            document.getElementById('result').value = (+input).toString(2);
        }
        else if (convertTo === 'hexadecimal') {

            document.getElementById('result').value = (+input).toString(16);
        }
    }

    function populateSelectedMenuTo(selectMenuTo) {

        let binaryElement = document.createElement('option');
        binaryElement.value = 'binary';
        binaryElement.textContent = 'Binary';

        let hexadecimalElement = document.createElement('option');
        hexadecimalElement.value = 'hexadecimal';
        hexadecimalElement.textContent = 'Hexadecimal';


        selectMenuTo.appendChild(binaryElement);
        selectMenuTo.appendChild(hexadecimalElement);
    }
}



