function getNext() {
    let number = document.getElementById('num').value;
    let hailstoneNumbers = [number];

    while (Number(number) !== 1){
        if (number % 2 === 0){
            number /= 2;

        } else {
            number = (3 * number) + 1;
        }

        hailstoneNumbers.push(number);
    }

    document.getElementById('result').textContent = hailstoneNumbers.join(' ') + ' ';
}