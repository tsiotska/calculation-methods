//Open index.html in browser and press F12
func = (x) => {
  return Math.pow(x, 4) + Math.pow(x, 2) + x + 1;
};

Execute = (a, b, e, callback) =>{
  const L = b;
  const h = 2 * e / L;
  const x = [], fx = [];
  x.push(a + h / 2);
  fx.push(func(x[0]));

  while ((x[x.length - 1] + h) <= b) {
   callback(x, fx, h, L);
   fx.push(func(x[x.length - 1]));
  }

  let minFx = Math.min(...fx);
  let index = fx.indexOf(minFx);
  console.log(callback.name);
  console.log("min f(x) is " + minFx + "\n" + "and x is: " + index)
};

passiveSorting = (x, fx, h) =>{
  x.push(x[x.length - 1] + h);
};

completeSorting  = (x, fx, h, L) =>{
  x.push(x[x.length - 1] + h + ((func(x[x.length - 1]) - fx[fx.length - 1]) / L));
};


Execute(-1, 2, 0.05, passiveSorting);
Execute(-1, 2, 0.05, completeSorting);
