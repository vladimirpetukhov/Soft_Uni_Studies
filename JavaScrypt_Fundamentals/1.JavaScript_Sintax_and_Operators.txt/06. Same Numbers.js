function  sameNumbers(numbers) {
    numbers=numbers.toString();
    let result=true;
    let sum=+numbers[0];

    for(let i=1; i< numbers.length; i++){
        if(numbers[i-1]!==numbers[i]){
            result= false;
        }
        sum+=+numbers[i];
    }
    console.log(result);
    console.log(sum);
}

sameNumbers(1234);
