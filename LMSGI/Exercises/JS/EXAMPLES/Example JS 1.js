// alert('Hola Mundo')

// var edad, nombre;
// nombre = prompt('Introduzca su nombre')
// edad = prompt('Ingrese su edad');

// if(edad >= 18 && nombre == 'Pepe')
// {
//     alert('Eres mayor de edad y además don Pepe');
// }
// else if(edad >= 18 || nombre == 'Pepe')
// {
//     if(edad >= 18)
//     {
//         alert('Eres mayor de edad');
//     }
//     else
//     {
//         alert('Eres don Pepe');
//     }
// }
// else
// {
//     alert('Todavía eres menor de edad');
// }

// var x=1;
// while ( x <= 100)
// {
//     document.write(x);
//     document.write('<br>');
//     x++;
// }

// for(var f = 1; f <= 100; f++)
// {
//     document.write(f + ' ');
// }

// var y;
// do{
//     y = parseInt(prompt("Introduce un valor entre 0 y 999. El 0 acabaría el bucle"));
//     document.write('El valor ' + y + ': ');
//     if(y < 10)
//     {
//         document.write('tendría un digito');
//     }
//     else if (y > 100)
//     {
//         document.write('tendríados digitos');
//     }
//     else
//     {
//         document.write('tendría tres digitos');
//     }
//     document.write('<br>');

// }while(y != 0);

// var num;
// do{
//     num = parseInt(prompt("Introduce un valor entre 0 y 999. El 0 acabaría el bucle"));
//     document.write('El valor ' + num + ': ');
//     if(num % 2 == 0)
//     {
//         document.write('sería par');
//     }
//     else
//     {
//         document.write('sería impar');
//     }
//     document.write('<br>');
// }while(num != 0);

// for(let i=2; i<=100;i+=2)
// {
//     document.write(i + ' ');
// }

// let sum = 0;

// for (let i = 1; i <= 10; i++) 
// {
//     document.write(sum + ' + ' + i + ' = ' + (sum + i) + '<br>');
//     sum += i;
// }

// debugger;
// const randNum = Math.floor(Math.random()*10)+1;
// var error = false;
// var count = 0;
// while(!error)
// {
//     var num = prompt('Adivina el número aleatorio: ');
//     if(num != randNum)
//     {
//         count++;
//     }
//     else
//     {
//         alert('Lo encontraste!');
//         error = true;
//     }
//     if(count == 3)
//     {
//         alert('Intentos agotados');
//         error = true;
//     }
// }

// Crear funciones que devuelvan el último y el primer elemento del vector

// function lastValueArray(array)
// {
//     return array[array.length-1];
// }

// var answer = lastValueArray([4,8,5]);
// document.write(answer);

// function firstValueArray(array)
// {
//     return array[0];
// }

// var answer = lastValueArray([4,8,5]);
// document.write(answer);

// Que sume todos los datos

// let array = [1,2,3,4,5,6,7,8,9,10];
// function addValues(array)
// {
//     let sum = 0;
//     for(let i = 0; i < array.Length;i++)
//     {
//         sum += array[i];
//     }
//     return sum;
// }
// document.write(addValues(array))

// function create()
// {
//     var nodeTitle = document.createElement('title');
//     var txtTitle = document.createTextNode('Hello');
//     nodeTitle.appendChild(txtTitle);
//     document.head.appendChild(nodeTitle);
// }

// function create()
// {
//     var newH1 = document.createElement("h1");
//     var txtH1 = document.createTextNode('SANTI NOT TRUE^FALSE');
//     newH1.appendChild(txtH1);
//     document.body.appendChild(newH1);
// }

// function create() {
//     let preToothless = document.getElementById("T1");

//     preToothless.addEventListener("load", () => {
//         console.log("Image loaded");
//         if (preToothless.alt === "T1") {
//             preToothless.src = "Toothless.gif";
//             preToothless.alt = "T2";
//         } else {
//             preToothless.src = "previousToothless.gif";
//             preToothless.alt = "T1";
//         }
//     });
// }


// let preToothless = document.getElementById("T1");

// function changeImg()
// {
// windows.setTimeout(function(){
//     preToothless.src = "Toothless.gif";
// }, 500);
// }
