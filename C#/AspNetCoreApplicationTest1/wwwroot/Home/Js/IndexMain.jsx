/*
class Hello extends React.Component {
    constructor(props) { super(props); 
        this.state = { Text: "" }; this.H1_Click = this.H1_Click.bind(this);
    } 

    H1_Click = Text => { this.setState({ Text: "Event," }); console.log("Event"); }; 

    render = () => <h1 onClick = {this.H1_Click} >
                    Привет From Object FuncConstruct(), {this.state.Text} .NET, React.JS
               </h1>; 
} 

class Hello2 extends React.Component {
    //constructor(props) { super(props);
        Count = 1; Text = "" ; //this.H1_Click = this.H1_Click.bind(this);
//    }

    H1_Click = Text => {
        this.Text = `Event${this.Count++},`; //this.Count
        console.log("Event"); ReactDOM.render(<Hello2 />, document.getElementById("content"));
    };

    render = () => { console.log(`Text = ${this.Text}`); return <h1 onClick = {this.H1_Click} >
        Привет From Object FuncConstruct2(), {this.Text} .NET, React.JS
    </h1>; } 
} */

function UpdateContentHTML_State(MainDivID) { const ThisPrivateMainDivID = MainDivID; 
    this.Handle = function(Context) { ReactDOM.render(<Context.render />, ($(`#${ThisPrivateMainDivID}`))[0]); }; 
} 

function UpdateConsole_State() {
    this.Handle = function(Text) { console.log(`Console: ${Text}`) };
} 

function ClassText(PrivateState) { //this.__proto__ = new React.Component; 
    var Count = 1, Text = ""; 
    const row = [14, 11, 47]; 

    function PrintArray(Params)
    {
        var NewArray = new Array(3), Index = 0;
        for (const Param of Params) NewArray[Index++] = <li> Param </li>;
        return NewArray;
    } 

    function H1_Click(Txt)
    {
        if (Count == 4)
        {
            Count = 1;
            ThisPrivateState = new UpdateConsole_State();
        }
        Text = `${Txt}${Count++}0,`;
        ThisPrivateState.Handle(ThisPrivate);
    }; 

    this.render = () => <h1 onClick = { () => H1_Click('Event') } > 
                            Привет From Object FuncConstruct(), {Text} .NET, React.JS 
                        </h1>; 

    this.SetState = function(PrivateState) { ThisPrivateState = PrivateState; }; 

    const ThisPrivate = this; var ThisPrivateState = PrivateState; 

} 

ClassText.prototype = new React.Component();
//ClassText.__proto__ = new React.Component(); 

const NewClassText = new ClassText(new UpdateContentHTML_State("content")); 

ReactDOM.render(<NewClassText.render />, document.getElementById("content")); 
//ReactDOM.render(<ClassText />, document.getElementById("content"));

