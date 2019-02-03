function validate() {
    document.querySelector('#exercise div button').addEventListener('click', clickEvent);
    let months = { January: '01', February: '02', March: '03', April: '04', May: '05', June: '06', July: '07', August: '08', September: '09', October: '10', November: '11', December: '12' }

    function clickEvent(e){
        let year = document.getElementById('year');
        let month = Array.from(document.getElementById('month').children).filter(x => x.selected)[0];
        let date = document.getElementById('date');
        let region = document.getElementById('region');
        let gender = Array.from(document.getElementsByName('gender')).filter(x => x.checked)[0];

        if (year.value === '' || month.value === '' || date.value === '' || region.value === '' || gender === undefined ||
            region.value < 43 || region.value > 999 || year < 1900 || year > 2100){
            return;
        }

        let egnBase = `${year.value.split('').slice(2).join('')}${months[month.value]}${date.value.padStart(2, '0')}${region.value}`;

        let genderDigit = gender.value === 'Male' ? 2 : 1;
        let egn = egnBase.split('').slice(0, 8).join('') + genderDigit;

        let weight = [2, 4, 8, 5, 10, 9, 7, 3, 6];
        let numbers = egn.split('');

        let lastDigit = 0;
        for (let i = 0; i < numbers.length; i++) {
            lastDigit += Number(numbers[i]) * Number(weight[i]);
        }

        lastDigit = lastDigit % 11 === 10 ? 0 : lastDigit % 11;
        egn += lastDigit;

        document.getElementById('egn').textContent = 'Your EGN is: ' + egn;
        document.getElementById('month').children[0].selected = 'selected';
        gender.checked = false;
        year.value = '';
        date.value = '';
        region.value = '';
    }
}