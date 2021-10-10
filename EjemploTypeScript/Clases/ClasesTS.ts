class cPersona{

//Atributos
    sNombre:string;
    sApellido:string;
    nEdad:number;

    //Métodos o acciones
    //Constructor por defecto
    constructor(p_sNombre:string, p_sApellido:string,p_nEdad:number){
        this.sNombre   = p_sNombre;
        this.sApellido =p_sApellido;
        this.nEdad     = p_nEdad;
    }

    public mHablar(){
        console.log("Hola soy "+this.sNombre);
    }
}

let objPersona:cPersona;

objPersona = new cPersona("Jose","Ramirez",22);

objPersona.mHablar();