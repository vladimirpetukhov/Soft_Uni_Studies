function binarySearch() {
    function binarySearch() {
        let arr = document.getElementById('arr').value.split(', ');
        let number = document.getElementById('num').value;
        let index = arr.indexOf(number);

        document.getElementById('result')
            .textContent = index < 0 ? `${number} is not in the array` : `Found ${number} at index ${index}`
    }
}