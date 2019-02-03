function solve() {
    let carts = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    document.querySelector('#exercise button').addEventListener('click', getCards);

    function getCards() {

        let fromCard = document.getElementById('from');
        let toCard = document.getElementById('to');
        let option = Array.from(document.querySelector('#exercise select').children)
            .filter(x => x.selected)[0].value.split(' ').slice(1);
        let fromIndex = carts.indexOf(fromCard.value.toUpperCase());
        let endIndex = carts.indexOf(toCard.value.toUpperCase());
        if(fromIndex<0 || fromIndex>carts.length-1 ||
            endIndex<0 || fromIndex>carts.length-1){
            fromCard.value='';
            toCard.value='';
            alert('Invalid Index');
            return;
        }
        for (let i = fromIndex; i <= endIndex; i++) {
            let div = document.createElement('div');
            div.classList.add('card');
            let p1 = document.createElement('p');
            p1.textContent = carts[i];
            let p2 = document.createElement('p');
            p2.textContent = option;
            let p3 = document.createElement('p');
            p3.textContent = option;
            document.getElementById('cards').appendChild(div);

            div.appendChild(p2);
            div.appendChild(p1);
            div.appendChild(p3);
        }
    }
}