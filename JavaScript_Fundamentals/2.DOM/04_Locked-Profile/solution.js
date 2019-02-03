function solve(e) {
    Array.from(document.getElementsByClassName('profile'))
        .forEach(p => p.getElementsByTagName('button')[0]
            .addEventListener('click', clickEvent));

    function clickEvent(e) {

        let hiddenField=Array.from(e.target.parentElement.getElementsByTagName('div'))
            .filter(x=> x.id.includes('HiddenFields'))[0];


        let radioButton=Array.from(document.getElementsByTagName('input'))
            .filter(x=> x.name.includes('Locked') && x.checked)[0];

        if(radioButton.value==='unlock' && e.target.textContent==='Show more'){

            hiddenField.style.display='inline';
            e.target.textContent='Hide it';
        }
        else if(e.target.textContent==='Hide it' && radioButton.value==='unlock'){

            hiddenField.style.display='none';
            e.target.textContent='Show more';

        }


    }







}

