//Open index.html in browser and press F12
const Function = (x) => {
  return Math.pow(x, 4) + Math.pow(x, 2) + x + 1;
};

const passiveSorting = (a, b, e) =>{
 // const dx = math.derivative('x^4+x^2+x+1', 'x').evaluate({x : a});
  /*Не розумію чому не працює метод evaluate (math це бібліотека), Нехай ліпшиця буде b*/
  const L = b;
  const h = 2 * e / L;
  const x = [], fx = [];
  x.push(a + h / 2);
  fx.push(Function(x[0]));

  while ((x[x.length - 1] + h) <= b) { //між а та б!
    x.push(x[x.length - 1] + h);
    fx.push(Function(x[x.length - 1]));
  }

  let minFx = Math.min(...fx);
  console.log("min f(x) is " + minFx)
};

passiveSorting(-1, 2, 0.05);
