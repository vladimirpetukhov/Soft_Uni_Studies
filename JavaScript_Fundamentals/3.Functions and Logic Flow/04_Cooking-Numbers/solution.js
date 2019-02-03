function solve() {
    let buttons = document.querySelectorAll('#exercise button');
    buttons[0].addEventListener('click', chop);
    buttons[1].addEventListener('click', dice);
    buttons[2].addEventListener('click', spice);
    buttons[3].addEventListener('click', bake);
    buttons[4].addEventListener('click', fillet);

    function getNumber() {
        let number = document.getElementById('output').textContent ||
            document.querySelector('#exercise input').value;

        return Number(number);
    }

    function chop() {
        let number = getNumber();
        document.getElementById('output').textContent = number / 2;
    }

    function dice() {
        let number = getNumber();
        document.getElementById('output').textContent = Math.sqrt(number);
    }

    function spice() {
        let number = getNumber();
        document.getElementById('output').textContent = number += 1;
    }

    function bake() {
        let number = getNumber();
        document.getElementById('output').textContent = number *= 3;
    }

    function fillet() {
        let number = getNumber();
        document.getElementById('output').textContent = number *= 0.8;
    }
}