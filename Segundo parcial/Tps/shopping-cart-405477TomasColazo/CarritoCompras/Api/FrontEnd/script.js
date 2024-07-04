$(function () {
  $("#guardar").click(function () {
    $("#error1").hide();
    $("#error2").hide();
    $("#error3").hide();
    $("#error4").hide();
    $("#error5").hide();
  });
  $.validator.addMethod(
    "maxLength",
    function (value, element, param) {
      return value.length <= param;
    },
    $.validator.format("Ingrese menos de {0} caracteres.")
  );
  $.validator.addMethod(
    "minValue",
    function (value, element, param) {
      return value >= param;
    },
    $.validator.format("Ingrese mas de {0} caracteres.")
  );
  $("form").validate({
    rules: {
      nombre: {
        required: true,
        maxlength: 30,
      },
      apellido: {
        required: true,
        maxlength: 20,
      },
      hsVuelo: {
        required: true,
        minValue: 50,
      },
      tipoVuelo: {
        required: true,
      },
      nacionalidad: {
        required: true,
      },
    },
    messages: {
      nombre: {
        required: "Debe ingresar un nombre.",
        maxlength: "El nombre no puede tener mas de {0} caracteres.",
      },
      apellido: {
        required: "Debe ingresar un apellido.",
        maxlength: "El apellido no puede tener mas de {0} caracteres.",
      },
      hsVuelo: {
        required: "Debe ingresar la cantidad de horas de vuelo.",
        minValue: "Debe ingresar al menos {0} horas de vuelo.",
      },
      tipoVuelo: {
        required: "Debe seleccionar el tipo de vuelo.",
      },
      nacionalidad: {
        required: "Debe seleccionar la nacionalidad.",
      },
    },
    errorPlacement: function (error, element) {
      switch (element.attr("name")) {
        case "nombre":
          $("#error1").text(error.text()).show();
          break;
        case "apellido":
          $("#error2").text(error.text()).show();
          break;
        case "hsVuelo":
          $("#error3").text(error.text()).show();
          break;
        case "tipoVuelo":
          $("#error4").text(error.text()).show();
          break;
        case "nacionalidad":
          $("#error5").text(error.text()).show();
          break;
        default:
          break;
      }
    },
    submitHandler: function (form) {
      $("li").hide();
      form.submit();
      window.alert(
        "Se ha guardado el formulario con exito!!!\n" +
          "Nombre: " +
          $("#inputNombre").val() +
          "\nApellido: " +
          $("#inputApellido").val() +
          "\nCantidad de horas voladas: " +
          $("#inputHsVuelo").val() +
          "\nTipo de vuelo: " +
          $("input[name='tipoVuelo']:checked").val() +
          "\nNacionalidad: " +
          $("#nacionalidad").val()
      );
    },
  });
});
