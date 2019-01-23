function solve(order) {

    let totalSum = 0;
    let result = '';

    order.forEach(element => {

        let input = element.split(', ');
        let insertedCoins = input[0];
        let orderSum = 0;

        let drink = input[1];
        let drinkPrice = getDrinkPrice(drink, input[2]);

        let s = input[input.length - 1];
        let sugar = getSugarPrice(s);


        orderSum = increaseOrder(input);
        
        totalSum += displayResult(insertedCoins, orderSum, drink);
    });

    console.log(`Income Report: ${totalSum.toFixed(2)}`);
}

function getDrinkPrice(drink, drinkType) {

    if (drink === 'coffee' && drinkType === 'decaf') {

        return 0.90;
    }
    return 0.80;
}

function getSugarPrice(s) {

    if (s < 1) {

        return 0;
    }

    return 0.10;
}

function increaseOrder(input) {

    let drink = input[1];
    let drinkPrice = getDrinkPrice(drink,input[2]);
    let sugar = getSugarPrice(input[input.length - 1]);
    let milk = Math.ceil((drinkPrice * 0.1)) / 10;
    let fullDrink = (drinkPrice + sugar + milk);
    let halfDrink = (drinkPrice + sugar);

    let sum = 0;

    if (drink === 'coffee') {

        if (input.length == 5) {

            return fullDrink;
        }
        return halfDrink;
    } else {

        if (input.length === 4) {

            return fullDrink;
        }

        return halfDrink;
    }
}

function displayResult(insertedCoins, orderSum, drink) {
    let moneyDiff = Math.abs(orderSum - insertedCoins).toFixed(2);
    if (insertedCoins < orderSum) {

        console.log(`Not enough money for ${drink}. Need ${moneyDiff}$ more`);
        return 0;

    } else {

        console.log(`You ordered ${drink}. Price: ${orderSum.toFixed(2)}$ Change: ${moneyDiff}$`);
        return orderSum;
    }
}
solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
'1.00, coffee, decaf, 0']
);