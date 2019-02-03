function solve() {
    document.querySelector('[name="myBtn"]').addEventListener('click', clickEvent);
    document.querySelector('[name="peshoBtn"]').addEventListener('click', clickEvent);

    function clickEvent(e) {

        let sender=e.target;

        let div=document.createElement('div');
        let span=document.createElement('span');
        let p=document.createElement('p');

        if(sender.name==='myBtn'){

            span.textContent='Me';

            let myInput=document.getElementById('myChatBox');

            p.textContent=myInput.value;

            myInput.value='';
            div.style.textAlign='left';
        }
        else {

            span.textContent='Pesho';

            let myInput=document.getElementById('peshoChatBox');

            p.textContent=myInput.value;
            myInput.value='';
            div.style.textAlign='right';

        }

        let chat=document.getElementById('chatChronology');

        div.appendChild(span);
        div.appendChild(p);

        chat.appendChild(div);
    }

}

