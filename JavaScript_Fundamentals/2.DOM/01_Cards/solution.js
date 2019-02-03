function solve(){
    Array.from(document.getElementsByTagName('img')).forEach(img =>
        img.addEventListener('click', clickEvent))


    function clickEvent(e) {
        let card=e.target;
        card.src = 'images/whiteCard.jpg';
        card.removeEventListener('click',clickEvent);

        let cardNumber=Number(card.name);
        let spans=document.getElementById('result').children;

        let leftSpan=spans[0];
        let rightSpan=spans[2];

        let parent=card.parentNode;
        if(parent.id==='player1Div'){


            firstElement=card;
            leftSpan.textContent=card.name;
        }else {

            secondElement=card;
            rightSpan.textContent=card.name;
        }

        if(leftSpan.textContent && rightSpan.textContent){

            let number1=firstElement.name;
            let number2=secondElement.name;

            if(number1>number2){

                firstElement.style.border = '2px solid green';
                secondElement.style.border = '2px solid darkred';
            } else {
                firstElement.style.border = '2px solid darkred';
                secondElement.style.border = '2px solid green';
            }

            let history=document.getElementById('history');
            history.textContent+=`[${number1} vs ${number2}] `;
            history.align='left';
            leftSpan.textContent = '';
            rightSpan.textContent = '';
        }



    }



}

