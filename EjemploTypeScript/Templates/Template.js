var cPersona = /** @class */ (function () {
    //Métodos o acciones
    //Constructor por defecto
    function cPersona(p_sNombre, p_sApellido, p_nEdad) {
        this.sNombre = p_sNombre;
        this.sApellido = p_sApellido;
        this.nEdad = p_nEdad;
    }
    cPersona.prototype.mHablar = function () {
        console.log("Hola soy: " + this.sNombre + " " + this.sApellido + " y mi edad es " + this.nEdad + " a\u00F1os");
    };
    return cPersona;
}());
var objPersona;
objPersona = new cPersona("Jose", "Ramirez", 22);
objPersona.mHablar();
