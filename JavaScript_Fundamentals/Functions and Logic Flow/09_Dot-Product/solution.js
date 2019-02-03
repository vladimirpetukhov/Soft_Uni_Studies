function solve() {
    function solve() {
        let firstMatrix = JSON.parse(document.getElementById('mat1').value);
        let secondMatrix = JSON.parse(document.getElementById('mat2').value);

        secondMatrix = secondMatrix[0].map((col, i) => secondMatrix.map(row => row[i]));

        let matrix = multiply(firstMatrix, secondMatrix);

        for (let array of matrix) {
            let p = document.createElement('p');
            p.textContent = array.join(', ');

            document.getElementById('result').appendChild(p);
        }

        function multiply(firstMatrix, secondMatrix) {
            let matrix = [];
            for (let r = 0; r < firstMatrix.length; ++r) {
                matrix[r] = [];
                for (let c = 0; c < secondMatrix[0].length; ++c) {
                    matrix[r][c] = 0;
                    for (let i = 0; i < firstMatrix[0].length; ++i) {
                        matrix[r][c] += firstMatrix[r][i] * secondMatrix[i][c];
                    }
                }
            }
            return matrix;
        }
    }
}