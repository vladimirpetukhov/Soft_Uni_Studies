function fruit(product,weight,money){
    weight=Number(weight)/1000;
    money=Number(money);
    let total=(money*weight).toFixed(2);
    console.log(`I need ${total} leva to buy ${weight.toFixed(2)} kilograms ${product}.`);
}
fruit('orange', 2500, 1.80);