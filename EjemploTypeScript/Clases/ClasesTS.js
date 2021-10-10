var cPersona = /** @class */ (function () {
    //Métodos o acciones
    //Constructor por defecto
    function cPersona(p_sNombre, p_sApellido, p_nEdad) {
        this.sNombre = p_sNombre;
        this.sApellido = p_sApellido;
        this.nEdad = p_nEdad;
    }
    cPersona.prototype.mHablar = function () {
        console.log("Hola soy " + this.sNombre);
    };
    return cPersona;
}());
var objPersona;
objPersona = new cPersona("Jose", "Ramirez", 22);
objPersona.mHablar();
