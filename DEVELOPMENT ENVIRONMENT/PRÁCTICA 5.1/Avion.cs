public class Avion
{
    private float altura;
    private float velocidad;
    private float combustible;
    private int orientaci�n;

    public Avion(float altura, float velocidad, float combustible, int orientacion)
    {
        this.altura = altura; 
        this.velocidad = velocidad;
        this.combustible = combustible; 
        this.orientaci�n = orientacion;
    }

    public float Altura
    {
        get { return this.altura; }
        set { this.altura = value; }
    }

    public int Orientacion
    {
        get { return this.orientaci�n; }
        set { this.orientacion = value; }
    }

    public float Combustible
    { 
        get { return this.combustible; }
        set { this.combustible = value; }
    }

    //Metodo que sirve para girar respecto a los grados indicados.
    private void Virar(int grados)
    {
        orientaci�n = (orientaci�n + grados) % 360;
        ConsumirFuel(grados * 0.1);
    }

    //Metodo que sirve para ascender respecto a los metros indicados.
    private void Ascender(float metros)
    {
        altura += metros;
        ConsumirFuel(metros * 0.3);
    }

    //Metodo que sirve para descender respecto los metros indicados.
    private void Descender(float metros)
    {
        altura -= metros;
        if (altura < 0)
        {
            altura = 0;
        }
    }

    //Metodo que sirve para consumir combustible respecto los litros indicados.
    private void ConsumirFuel(float litros)
    {
        combustible -= litros;
        if (combustible < 0)
        {
            combustible = 0;
        }
    }
}