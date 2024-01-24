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
