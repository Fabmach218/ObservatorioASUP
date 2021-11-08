// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let count = 6;
let porcentaje = 0;
 function redireccion(){

   
   
    if(window.location.pathname === "/Identity/Account/ConfirmEmail"){

        mensaje();
        setInterval(mensaje , 1000);
        setTimeout("redirect()", 5000);

    }

}



function redirect(){

    window.location.href = "https://app-observatorio-asup.herokuapp.com/Identity/Account/Login";

  }

function mensaje(){

    const texto = document.querySelector('#mensaje');
    let barrita = document.querySelector('.progress-bar');
    count--;
 
    if(count < 0){

        count = 0;
    }
    
    if(porcentaje > 100){

        porcentaje = 100;

    }
    
    texto.textContent = "Su correo a sido confirmado se le redireccionara a la pagina de inicio de sesión en: " + count + " segundos";
    barrita.ariaValueNow = porcentaje;
    barrita.innerHTML = porcentaje + "%";
    barrita.style.width = porcentaje + "%";
    porcentaje+= 25;
    

    

}

function mostrarPassword(campo) {
    var pass = document.getElementById(campo);
    if (pass.type === "password") {
      pass.type = "text";
    } else {
      pass.type = "password";
    }
  }