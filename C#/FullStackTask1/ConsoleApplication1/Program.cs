
IFigure figure = new Circle(2.0F); 
System.Console.WriteLine($"S(cirle) = {figure.GetSquare()}, "); 

IFigureFactory newFigureFactory = new FigureCircleFactory(2F); 
IFigure newFigure = newFigureFactory.CreateFigure(); 
System.Console.WriteLine($"S(circle) = {newFigure.GetSquare()}, \n"); 


figure = new Triangle( new System.Single[3] { 3F, 4F, 5F } ); 
System.Console.WriteLine($"S(triangle) = {figure.GetSquare()}, "); 

newFigureFactory = new FigureTriangleFactory( new System.Single[3] { 5F, 4F, 3F } ); 
newFigure = newFigureFactory.CreateFigure(); 
System.Console.WriteLine($"S(triangle) = {newFigure.GetSquare()}, \n"); 


Triangle newTriangle = new Triangle( new System.Single[3] { 5F, 4F, 4F } ); 
System.Console.WriteLine("IsRightTriangle()? = " + newTriangle.IsRightTriangle()); 


public interface IFigure 
{ 
    System.Single GetSquare(); 
} 

internal class Circle : IFigure
{ 
    const System.Single THIS_PI = (System.Single) Math.PI;
    readonly System.Single radius; 

    public Circle(System.Single radius) 
    {
        this.radius = radius; 
    }

    public System.Single GetSquare() => 2 * THIS_PI * radius; 
} 

internal class Triangle : IFigure
{ 
    const System.Byte LENGTH = 3; 
    readonly System.Single []arrayEdgeBorders; 

    private void Swap() 
    { 
        System.Single []arrayHypotenuse = new System.Single[2] 
        { 
            arrayEdgeBorders[0], 0
        }; 

        for (System.Byte i = 1; i < LENGTH; i++)
        {
            System.Single value = arrayEdgeBorders[i]; 
            if (value > arrayHypotenuse[0])
            {
                arrayHypotenuse[0] = value; 
                arrayHypotenuse[1] = i; 
            }
        }
        
        if (arrayHypotenuse[1] != LENGTH - 1)
        { 
            System.Byte iTemporary = (System.Byte) arrayHypotenuse[1]; 
            System.Single valueTemporary = arrayEdgeBorders[iTemporary]; 
            arrayEdgeBorders[iTemporary] = arrayEdgeBorders[LENGTH - 1]; 
            arrayEdgeBorders[LENGTH - 1] = valueTemporary; 
        } 
    }

    public Triangle(in Triangle inTriangle) 
    {
        arrayEdgeBorders = new System.Single[LENGTH + 1]
        {
            0, 0, 0, 0 
        }; 

        if (inTriangle != null) 
            for (System.Byte i = 0; i <= LENGTH; i++)
                arrayEdgeBorders[i] = inTriangle.arrayEdgeBorders[i]; 
    }

    public Triangle(System.Single []arrayEdgeBorders) 
    {
        this.arrayEdgeBorders = new System.Single[LENGTH + 1]
        {
            0, 0, 0, 0 
        }; 

        System.Byte systemByteLength = (System.Byte) arrayEdgeBorders.Length; 
        systemByteLength = ( systemByteLength > LENGTH ? LENGTH : systemByteLength ); 
        System.Single perimetr2 = 0; 
        for (System.Byte i = 0; i < systemByteLength; perimetr2 += arrayEdgeBorders[i], i++)
            this.arrayEdgeBorders[i] = arrayEdgeBorders[i]; 

        Swap(); 
        this.arrayEdgeBorders[LENGTH] = 0.5F * perimetr2; 
    }

    public System.Single GetSquare() => (System.Single) System.Math.Sqrt( arrayEdgeBorders[LENGTH] * (arrayEdgeBorders[LENGTH] - arrayEdgeBorders[0]) * (arrayEdgeBorders[LENGTH] - arrayEdgeBorders[1]) * (arrayEdgeBorders[LENGTH] - arrayEdgeBorders[2]) ); 

    public System.Boolean IsRightTriangle() => arrayEdgeBorders[0] * arrayEdgeBorders[0] + arrayEdgeBorders[1] * arrayEdgeBorders[1] == arrayEdgeBorders[2] * arrayEdgeBorders[2]; 
} 

public interface IFigureFactory
{ 
    IFigure CreateFigure(); 
//    IFigure CreateFigureTriangle(); 
} 

internal class FigureCircleFactory : IFigureFactory
{
    private readonly System.Single radius = 0; 

    public FigureCircleFactory(System.Single radius) => this.radius = radius; 

    public IFigure CreateFigure() => new Circle(radius);
} 

internal class FigureTriangleFactory : IFigureFactory
{
    private readonly System.Single []arrayEdgeBorders; 
    
    public FigureTriangleFactory(System.Single []arrayEdgeBorders) 
    {
        const System.Byte LENGTH = 3; 
        this.arrayEdgeBorders = new System.Single[LENGTH]
        {
            0, 0, 0 
        }; 

        System.Byte systemByteLength = (System.Byte) arrayEdgeBorders.Length; 
        systemByteLength = ( systemByteLength > LENGTH ? LENGTH : systemByteLength ); 
        for (System.Byte i = 0; i < systemByteLength; i++)
            this.arrayEdgeBorders[i] = arrayEdgeBorders[i]; 
    }

    public IFigure CreateFigure() => new Triangle(arrayEdgeBorders);
} 