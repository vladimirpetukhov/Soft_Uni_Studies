function solve() {

    let correctAnswers = { softUniYear:'2013', popularName: 'Pesho', softUniFounder: 'Nakov'};
    let correctAnswersCount = 0;
    let answersCount = 0;

    let questions = Array.from(document.getElementById('exercise').children);

    console.log(questions);
    questions.forEach(x => Array.from(x.getElementsByTagName('button'))[0]
        .addEventListener('click', clickEvent));


    function clickEvent(e) {
        console.log(e.target.parentNode);

        let parent = e.target.parentNode;
        let input = Array.from(parent.getElementsByTagName('input')).filter(x => x.checked)[0];

        if (!input){
            return;
        }

        if (correctAnswers[input.name] === input.value){
            correctAnswersCount++;
        }

        if (++answersCount < 3) {
            let nextQuestion = questions[answersCount];
            nextQuestion.style.display = 'inline';
        }

        if (e.target.textContent === 'Get the results'){
            if (correctAnswersCount === 3){
                document.getElementById('result').textContent = `You are recognized as top SoftUni fan!`;
            } else {
                document.getElementById('result').textContent = `You have ${correctAnswersCount} right answers`;
            }
        }
    }
}