function solve() {
    function solve() {
        let factors = number => Array
            .from(Array(number + 1), (_, i) => i)
            .filter(i => number % i === 0);

        let number = document.getElementById('num').value;

        document.getElementById('result').textContent = factors(Number(number)).join(' ');
    }
}