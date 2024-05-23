/* ----------------------------------- FUNCION INICIAL -----------------------------------------*/

// ESTE EVENTO SE DISPARA CUANDO SE CARGA COMPLETAMENTE EL CONTENIDO DEL DOCUMENTO
document.addEventListener("DOMContentLoaded", function() {

  // SELECCIONA TODAS LAS DIAPOSITIVAS E INICIALIZA EN 0
  let slides = document.querySelectorAll(".slide");
  let slideActual = 0;
  
  // FUNCIÓN PARA MOSTRAR UNA DIAPOSITIVA ESPECÍFICA
  function muestraSlide(index) {
    slides.forEach((slide, i) => {
      // SI EL ÍNDICE COINCIDE CON EL ÍNDICE DE LA DIAPOSITIVA ACTUAL, MUESTRA LA DIAPOSITIVA; DE LO CONTRARIO, OCÚLTALA
      if (i === index) {
        slide.style.display = "grid";
      } 
      else {
        slide.style.display = "none";
      }
    });
  }

/* ----------------------------------- FUNCION INICIAL -----------------------------------------*/

/* --------------------------------- FUNCIONES NAVEGACION --------------------------------------*/

  // FUNCIÓN PARA AVANZAR A LA SIGUIENTE DIAPOSITIVA
  function siguienteSlide() {
    if (slideActual < slides.length - 1) {
      slideActual++;
      muestraSlide(slideActual);
    }
  }

  // FUNCIÓN PARA RETROCEDER A LA ANTERIOR DIAPOSITIVA
  function anteriorSlide() {
    if (slideActual > 0) {
      slideActual--;
      muestraSlide(slideActual);
    }
  }

/* --------------------------------- FUNCIONES NAVEGACION --------------------------------------*/

/* --------------------------------- EVENTOS NAVEGACION ----------------------------------------*/

  // EVENTO PARA DETECTAR LAS TECLAS DE FLECHA PRESIONADAS PARA LA NAVEGACIÓN
  document.addEventListener("keydown", function(event) {
    if (event.key === "ArrowDown" || event.key === "ArrowRight") {
      siguienteSlide();
    } 
    else if (event.key === "ArrowUp" || event.key === "ArrowLeft") {
      anteriorSlide();
    }
  });

  // EVENTO PARA DETECTAR EL DESPLAZAMIENTO DE LA RUEDA DEL MOUSE PARA LA NAVEGACIÓN
  document.addEventListener("wheel", function(event) {
      if (event.deltaY > 0) {
        siguienteSlide();
      } 
      else {
        anteriorSlide();
      }
    });

/* --------------------------------- EVENTOS NAVEGACION ----------------------------------------*/

  muestraSlide(slideActual);
});
