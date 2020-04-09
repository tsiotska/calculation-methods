String.prototype.allReplace = function (obj) {
  let retStr = this;
  for (let x in obj) {
    retStr = retStr.replace(x, obj[x]);
  }
  return retStr;
};

func = (array) => {
return Math.pow(4 * array[0], 2) + Math.pow(4 * array[1], 2) + Math.pow(array[2],2) - array[0] * array[1] +
    2 * array[0] * array[2] + array[1] * array[2] - array[0] + array[1] - array[2];
};

createDerivative = (expression) => {
  return deriveExpression(expression); //Got it from lib
};

//Very hardcoded, i know
// We have to put x instead of X1 in lowercase. Then replace it with X1. And with others the same
const derivateX1 = createDerivative("4*x^2 + 4*X2^2 + X3^2 - x*X2 + 2*x*X3 + X2*X3 - x + X2 - X3").replace('x', 'X1');
const derivateX2 = createDerivative("4*X1^2 + 4*x^2 + X3^2 - X1*x + 2*X1*X3 + x*X3 - X1 + x - X3").replace('x', 'X2');
const derivateX3 = createDerivative("4*X1^2 + 4*X2^2 + x^2 - X1*X2 + 2*X1*x + X2*x - X1 + X2 - x").replace('x', 'X3');

gradf = (array) => {
  return [eval(derivateX1.allReplace({'X1': array[0], 'X2': array[1], 'X3': array[2]})),
    eval(derivateX2.allReplace({'X1': array[0], 'X2': array[1], 'X3': array[2]})),
    eval(derivateX3.allReplace({'X1': array[0], 'X2': array[1], 'X3': array[2]}))]
};

show = (x, fx) => {
  console.log("x: " + x + "\nf(x): " + fx);
};

gradient = (a, b, e) => {
  let k = 0, x = [[1, 1, 1]];

  while (true) {

    let result = gradf(x[k]);

    if (!vectorLength(result)) {
      show(x[k], func(x[k]));
      break;
    }

    let position = result.map((dx, i) => {
      return x[k][i] - a * dx
    });

    let edge = -a * e * Math.pow(vectorLength(result), 2);

    if (func(position) - func(x[k]) <= edge) {
      x.push(position);
      k++;

      if (vectorLength(gradf(x[k])) < 0.1) {
        console.log("RETURN IT!!!");
        show(x[k], func(x[k]));
        break;
      }
    } else {
      console.log(a);
      a *= b;
    }
  }
};

vectorLength = (array) => {
  let sum = 0;
  array.forEach((x) => {
    sum += Math.pow(x, 2);
  });
  return Math.sqrt(sum)
};

gradient(0.3, 0.9, 0.5);
