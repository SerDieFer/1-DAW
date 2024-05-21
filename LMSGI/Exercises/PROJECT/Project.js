
/* ----------------------------------- FUNCION INICIAL -----------------------------------------*/

// Este evento se dispara cuando se carga completamente el contenido del documento
document.addEventListener("DOMContentLoaded", function() {

    // Selecciona todas las diapositivas e inicializa en 0
    let slides = document.querySelectorAll(".slide");
    let slideActual = 0;
    
    // Función para mostrar una diapositiva específica
    function muestraSlide(index) {
      slides.forEach((slide, i) => {
        // Si el índice coincide con el índice de la diapositiva actual, muestra la diapositiva; de lo contrario, ocúltala
        if (i === index) {
            slide.style.display = "grid";
          } else {
            slide.style.display = "none";
          }
      });
    }

/* ----------------------------------- FUNCION INICIAL -----------------------------------------*/

/* --------------------------------- FUNCIONES NAVEGACION --------------------------------------*/

    // Función para avanzar a la siguiente diapositiva
    function siguienteSlide() {
      if (slideActual < slides.length - 1) {
        slideActual++;
        muestraSlide(slideActual);
      }
    }
  
    // Función para retroceder a la anterior diapositiva
    function anteriorSlide() {
      if (slideActual > 0) {
        slideActual--;
        muestraSlide(slideActual);
      }
    }

/* --------------------------------- FUNCIONES NAVEGACION --------------------------------------*/
  
/* --------------------------------- EVENTOS NAVEGACION ----------------------------------------*/

    // Evento para detectar las teclas de flecha presionadas para la navegación
    document.addEventListener("keydown", function(event) {
      if (event.key === "ArrowDown" || event.key === "ArrowRight") {
        siguienteSlide();
      } else if (event.key === "ArrowUp" || event.key === "ArrowLeft") {
        anteriorSlide();
      }
    });

    // Evento para detectar el desplazamiento de la rueda del mouse para la navegación
    document.addEventListener("wheel", function(event) {
        if (event.deltaY > 0) {
          siguienteSlide();
        } else {
          anteriorSlide();
        }
      });

/* --------------------------------- EVENTOS NAVEGACION ----------------------------------------*/
  
    muestraSlide(slideActual);
  });