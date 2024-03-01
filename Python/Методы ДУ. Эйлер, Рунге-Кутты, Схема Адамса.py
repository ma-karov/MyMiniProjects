import matplotlib.pyplot as Plt; import math; 

DIR_IMAGES = 'static/MainPagesMethods/Images/'

class Graphic: 
    def __init__(self):
        self.PltGraphic = Plt.figure(figsize = (10, 7), facecolor = 'green'); 
#    @staticmethod
    def Draw(self, Tuple: tuple, Switch: int) -> str:
        CoordAxis = self.PltGraphic.add_subplot(111, facecolor = '#ccc'); 
        TupleCoords = self._CalculateCoords(Tuple, Switch); 
        CoordAxis.plot(TupleCoords[0], TupleCoords[1], label = TupleCoords[3][0]); 
        CoordAxis.plot(TupleCoords[0], TupleCoords[2], label = TupleCoords[3][1]); 
        CoordAxis.grid(True); CoordAxis.legend(); return self._Save(); 

    def _CalculateCoords(self, Tuple: tuple, Switch: int) -> tuple:  
        if Switch == 1: return self._MethodEuler(Tuple); 
        if Switch == 2: return self._MethodRungeKutta(Tuple); 
        return self._MethodAdam(Tuple); 

    def _MethodEuler(self, Tuple: tuple) -> tuple:
        TupleNameLegends : tuple = tuple(); TupleCoordX : tuple = tuple(); 
        TupleCoordY : tuple = tuple(); TupleCoordY_Accuracy : tuple = tuple(); 
        Fxy = False; FxyAccuracy = False; 
        if Tuple[0] == "1": 
            Fxy = lambda TupleCoords: TupleCoords[1]*(TupleCoords[1] + 1); 
            FxyAccuracy = lambda TupleCoords: -math.exp(TupleCoords[0])/(math.exp(TupleCoords[0]) - 2*math.e); 
            TupleNameLegends = ('y1(x) = y^2 + y', 'y1(x) = -e^x/(e^x - 2e)'); 
        elif Tuple[0] == "2": 
            Fxy = lambda TupleCoords: 4*TupleCoords[0] + 2*TupleCoords[1]; 
            FxyAccuracy = lambda TupleCoords: 2*math.exp(2*TupleCoords[0]) - 2*TupleCoords[0] - 1; 
            TupleNameLegends = ('y2(x) = 4x + 2y', 'y2(x) = 2e^(2x) - 2x - 1'); 
        else: 
            Fxy = lambda TupleCoords: math.exp(TupleCoords[0]) + 2*TupleCoords[1]; 
            FxyAccuracy = lambda TupleCoords: math.exp(TupleCoords[0])*(math.exp(TupleCoords[0]) - 1); 
            TupleNameLegends = ('y3(x) = 2y + e^x', 'y3(x) = e^x (e^x - 1)'); 

        NewTuple : tuple = tuple(float(Tuple[i]) for i in range(5)); TupleCoordX = (NewTuple[1], ); TupleCoordY = (NewTuple[4], ); TupleCoordY_Accuracy = (NewTuple[4], ); 
        for i in range(int(math.fabs(NewTuple[1] - NewTuple[2])/NewTuple[3])): 
            TupleCoordX += (TupleCoordX[i] + NewTuple[3], ); 
            TupleValuesFx = (Fxy((TupleCoordX[i + 1], TupleCoordY[i])), FxyAccuracy((TupleCoordX[i + 1], TupleCoordY[i]))); 
            TupleCoordY += (TupleCoordY[i] + NewTuple[3]*TupleValuesFx[0], ); TupleCoordY_Accuracy += (TupleValuesFx[1], ); 
        return (TupleCoordX, TupleCoordY, TupleCoordY_Accuracy, TupleNameLegends); 

    def _MethodAdam(self, Tuple: tuple) -> tuple: 
        TupleNameLegends : tuple = tuple(); TupleCoordX : tuple = tuple(); 
        TupleCoordY : tuple = tuple(); TupleCoordY_Accuracy : tuple = tuple(); 
        Fxy = False; FxyAccuracy = False; 
        if Tuple[0] == "1": 
            Fxy = lambda TupleCoords: TupleCoords[1]*(TupleCoords[1] + 1); 
            FxyAccuracy = lambda TupleCoords: -math.exp(TupleCoords[0])/(math.exp(TupleCoords[0]) - 2*math.e); 
            TupleNameLegends = ('y1(x) = y^2 + y', 'y1(x) = -e^x/(e^x - 2e)'); 
        elif Tuple[0] == "2": 
            Fxy = lambda TupleCoords: 4*TupleCoords[0] + 2*TupleCoords[1]; 
            FxyAccuracy = lambda TupleCoords: 2*math.exp(2*TupleCoords[0]) - 2*TupleCoords[0] - 1; 
            TupleNameLegends = ('y2(x) = 4x + 2y', 'y2(x) = 2e^(2x) - 2x - 1'); 
        else: 
            Fxy = lambda TupleCoords: math.exp(TupleCoords[0]) + 2*TupleCoords[1]; 
            FxyAccuracy = lambda TupleCoords: math.exp(TupleCoords[0])*(math.exp(TupleCoords[0]) - 1); 
            TupleNameLegends = ('y3(x) = 2y + e^x', 'y3(x) = e^x (e^x - 1)'); 

        NewTuple : tuple = tuple(float(Tuple[i]) for i in range(5)); TupleCoordX = (NewTuple[1], ); TupleCoordY = (NewTuple[4], ); TupleCoordY_Accuracy = (NewTuple[4], ); 

        for i in range(2): 
            TupleCoordX += (TupleCoordX[i] + NewTuple[3], ); 
            TupleCoordY += (TupleCoordY[i] + NewTuple[3]*Fxy((TupleCoordX[i + 1], TupleCoordY[i])), ); TupleCoordY_Accuracy += (FxyAccuracy((TupleCoordX[i + 1], TupleCoordY[i])), ); 

            '''
            TupleCoordX += (TupleCoordX[i] + NewTuple[3], ); 
            TupleK : tuple = (NewTuple[3]*Fxy((TupleCoordX[i], TupleCoordY[i])), ); 
            TupleK += (NewTuple[3]*Fxy((TupleCoordX[i] + 0.5*TupleK[0], TupleCoordY[i] + 0.5*NewTuple[3])), );
            TupleK += (NewTuple[3]*Fxy((TupleCoordX[i] - 0.5*TupleK[1], TupleCoordY[i] + 0.5*NewTuple[3])), ); 
            TupleK += (NewTuple[3]*Fxy((TupleCoordX[i] + TupleK[2], TupleCoordY[i] + NewTuple[3])), ); 
            TupleCoordY += (TupleCoordY[i] + (TupleK[0] + 2*TupleK[1] + 2*TupleK[2] + TupleK[3])/6.0, ); 
            TupleCoordY_Accuracy += ( TupleCoordY_Accuracy[i] + FxyAccuracy((TupleCoordX[i], TupleCoordY[i])), ); 
            '''

        for i in range(2, int(math.fabs(NewTuple[1] - NewTuple[2])/NewTuple[3])): 
            TupleCoordX += (TupleCoordX[i] + NewTuple[3], ); 
            TupleCoordY += (TupleCoordY[i] + NewTuple[3]*(23*Fxy((TupleCoordX[i + 1], TupleCoordY[i]))/12 - 4*Fxy((TupleCoordX[i], TupleCoordY[i - 1]))/3 + 5*Fxy((TupleCoordX[i - 1], TupleCoordY[i - 2]))/12), ); TupleCoordY_Accuracy += (FxyAccuracy((TupleCoordX[i + 1], TupleCoordY[i + 1])), ); 
        return (TupleCoordX, TupleCoordY, TupleCoordY_Accuracy, TupleNameLegends); 

    def _MethodRungeKutta(self, Tuple: tuple) -> tuple: 
        NewTuple : tuple = tuple(float(Tuple[i]) for i in range(4)); 
        if Tuple[0] == "1": 
            Fxy = lambda TupleCoords: TupleCoords[0]**2; 
            FxyAccuracy = lambda TupleCoords: 1 + (TupleCoords[0]**4)/12.0; 
            TupleNameLegends = ('y\'\' = x^2', 'y(x) = 1 + x^4/12'); StartZ = float(Tuple[4][0]) 
            # y'' = x^2 => y' = z, z' = x^2 => y = y'(0) + z, z = y(0) + x^2  
            TupleCoordX = (NewTuple[1], ); TupleCoordY = (float(Tuple[4][1]), ); TupleCoordY_Accuracy = (TupleCoordY[0], ); 
            for i in range(int(math.fabs(NewTuple[1] - NewTuple[2])/NewTuple[3])): 
                TupleCoordX += (TupleCoordX[i] + NewTuple[3], ); 

                TupleK : tuple = (NewTuple[3]*Fxy((TupleCoordX[i + 0], TupleCoordY[i])), ); 
                TupleM : tuple = (NewTuple[3]*TupleK[0], ); 

                TupleK += (NewTuple[3]*Fxy((TupleCoordX[i + 0] + 0.5*TupleK[0], TupleCoordY[i] + 0.5*NewTuple[3])), );
                TupleM += (NewTuple[3]*TupleK[1], ); 

                TupleK += (NewTuple[3]*Fxy((TupleCoordX[i + 0] + 0.5*TupleK[1], TupleCoordY[i] + 0.5*NewTuple[3])), ); 
                TupleM += (NewTuple[3]*TupleK[2], ); 

                TupleK += (NewTuple[3]*Fxy((TupleCoordX[i + 0] + TupleK[2], TupleCoordY[i] + NewTuple[3])), ); 
                TupleM += (NewTuple[3]*TupleK[3], ); 

                TupleCoordY += (TupleCoordY[i] + StartZ + (TupleM[0] + 2*TupleM[1] + 2*TupleM[2] + TupleM[3])/6.0, ); 
                StartZ += (TupleK[0] + 2*TupleK[1] + 2*TupleK[2] + TupleK[3])/6.0;                 
                TupleCoordY_Accuracy += ( TupleCoordY_Accuracy[i] + FxyAccuracy((TupleCoordX[i + 0], TupleCoordY[i])), ); 
            return (TupleCoordX, TupleCoordY, TupleCoordY_Accuracy, TupleNameLegends); 

        elif Tuple[0] == "2": 
            Fxy = lambda TupleCoords: TupleCoords[0]**2; 
            FxyAccuracy = lambda TupleCoords: math.exp(2/TupleCoords[0]); 
            TupleNameLegends = ('y\'\' = 4y', 'y(x) = e^(2x)');

    def _Save(self):
        self.PltGraphic.savefig(DIR_IMAGES + 'Graphic.png'); return 'Graphic.png'; 

