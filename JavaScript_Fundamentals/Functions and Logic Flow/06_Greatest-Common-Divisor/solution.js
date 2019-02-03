function greatestCD() {

    function greatestCD() {
        let firstNumber = document.getElementById('num1').value;
        let secondNumber = document.getElementById('num2').value;

        document.getElementById('result').textContent = gcd(firstNumber, secondNumber);

        function gcd(a,b) {
            a = Math.abs(a);
            b = Math.abs(b);
            if (b > a) {
                var temp = a;
                a = b;
                b = temp;
            }
            while (true) {
                if (b == 0) {
                    return a;
                }

                a %= b;

                if (a == 0) {
                    return b;
                }

                b %= a;
            }
        }
    }
}