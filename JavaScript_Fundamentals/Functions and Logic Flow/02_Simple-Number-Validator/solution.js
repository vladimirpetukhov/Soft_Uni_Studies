function validate() {
    document.querySelector('div > button').addEventListener('click',clickEvent);
    function clickEvent() {
        let weight=[2, 4, 8, 5, 10, 9, 7, 3, 6];
        let numbers=document.querySelector('div input').value;
        let sum=0;
        for (let i = 0; i < numbers.length - 1; i++) {
            sum += Number(numbers[i]) * Number(weight[i]);
        }
        sum=sum%11;
        if(sum===10){
            sum=0;
        }
        if (Number(numbers[numbers.length - 1]) === sum) {
            document.getElementById('response').textContent = 'This number is Valid!';
        }else {
            document.getElementById('response').textContent = 'This number is NOT Valid!';
        }
    }
}