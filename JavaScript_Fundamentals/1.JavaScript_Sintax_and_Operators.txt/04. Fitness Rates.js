function solve(day, service, time) {
    let days = function (day) {
        return ['Monday',
            'Tuesday',
            'Wednesday',
            'Thursday',
            'Friday',
            'Saturday',
            'Sunday'
        ].indexOf(day);
    }
    let weekDays = {
        'Fitness': 5,
        'Sauna': 4,
        'Instructor': 10
    };
    let weekend = {
        'Fitness': 8,
        'Sauna': 7,
        'Instructor': 15
    };
    if (days(day)<= 4) {
        if (time <= 15) {
            return weekDays[service];
        } else {
            return weekDays[service] + 2.5;
        }
    } else {
        return weekend[service];
    }
}
console.log(solve('Monday', 'Sauna', 15.30));