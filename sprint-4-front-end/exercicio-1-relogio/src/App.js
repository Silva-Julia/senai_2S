import React from 'react';
import './App.css';

//Isso é um componente de função, que é basicamente uma função em JS
//Retonar um subtítlo com o horário atual
function DataFormatada(props) {
  return <h2> Horáril atual: {props.date.toLocaleTimeString()}</h2>
}


// Componente de classe
// Define a classe Clock que será chamada dentro da renderização do componente App
class Clock extends React.Component{
  
  //A responsabilidade do construtor é estabelecer a estrutura do componente.
  constructor(props){

    super(props);
    this.state = {

      // Define a propriedade date pegando a data e hora atual
      date : new Date() 
    };
  };

  // Define a função thick() que atualiza a propriedade date com a data e hora atual
  // toda vez que a função for invocada
  thick(){
    this.setState({
      date : new Date()
    })
  };

  // Ciclo de vida que ocorre quando o componente Clock é inserido na árvore DOM
  // ou seja, o ciclo de vida de montagem/nascimento
  componentDidMount(){
    this.timerID = setInterval( () => {
      this.thick()
    }, 1000 );

    // Exibe no console o ID de cada relógio
    console.log('Eu sou o relógio ' + this.timerID);
  };


  //função que para o relógio;
  Pausar(){

     this.componentWillUnmount()
    console.log('Relogio ${this.timerID} pausado');
  }

  //funçao que faz o relogio retornar
  Resume(){

    this.timerID = setInterval(() =>{
      this.thick();
    }, 1000);
    
    console.log('Relogio retomado');
    console.log('Agora eu sou o relógio ${this.timerID}');
  }
  


  // Ciclo de vida que ocorre quando o componente Clock é removido da árvore DOM
  // ou seja, o ciclo de vida da desmontagem/morte
  componentWillUnmount(){

    // a função clearInterval limpa o relógio criado pela função setInterval
    clearInterval(this.timerID);
  };

  // Renderiza o conteúdo do retorno na tela
  render(){
    return(
      <div>
        <h1>Relógio</h1>
        <DataFormatada date={this.state.date} />
        <button className = "btnPausar" onClick = { () => this.Pausar()}> Pausar o Relogio</button>
        <button className = "btnResume" onClick = { () => this.Resume()}> Retomar o Relogio</button>
      </div>
    )
  }

}

// Componente funcional
function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock />
        <Clock />
      </header>
    </div>
  );
}

export default App;

