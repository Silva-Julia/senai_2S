import { Component } from "react" ;

export default class UsuarioGit extends Component{

    constructor(props){
        super(props);
        this.state = {
            repositoriosNome: '',
            listaRepositorios: [],
            idRepositorio: 0,
            descricao: "",
            dataRepositorio: "",
            tamanho: 0
        }
    }

    buscarRepositorios = (elemento) =>
    {
        elemento.preventDefault();
        console.log("O repositorio esta sendo buscado")
        fetch('https://api.github.com/users/' + this.state.repositoriosNome + '/repos')
        .then(resposta => resposta.json())
        .then(lista => this.setState({listaRepositorios : lista}))
        .catch(erro => console.log(erro))
    }


    nomeAtualiza = async (name) =>
    {
        await this.setState({repositoriosNome : name.target.value})
        console.log(this.state.repositoriosNome)
    }

    componentDidMount() {

    }

    componentWillUnmount() {

    }
    
    render(){
        return(
            <div className= "App">
                <main className= "App">

                    <section className= "App-header">
                        <h2> Procure os usuarios do github </h2>
                        <form onSubmit= {this.buscarRepositorios}>
                            <div>
                                <input
                                type="text"
                                value={this.state.repositoriosNome}
                                onChange={this.nomeAtualiza}
                                placeholder="Usuario do GitHub"
                                />
                                <button type="submit" onClick= {this.buscarRepositorios}> Localizar </button>
                            </div>
                        </form>
                    </section>

                    <section className="App-header">
                        <table>
                            <thead>
                                <tr>
                                    <th> ID </th>
                                    <th> NAME </th>
                                    <th> DESCRIÇÃO </th>
                                    <th> DATA DE CRIAÇÃO </th>
                                    <th> TAMANHO </th>
                                </tr>
                            </thead>

                            <tbody>
                                {this.state.listaRepositorios.map((repositorio) => 
                                  {
                                    return(
                                        <tr key= {repositorio.id}>
                                            <td> {repositorio.id}</td>
                                            <td> {repositorio.name}</td>
                                            <td> {repositorio.descricao}</td>
                                            <td> {repositorio.criacao}</td>
                                            <td> {repositorio.size}</td>
                                        </tr>
                                    )
                                  })
                                }
                            </tbody>
                        </table>
                    </section>
                </main>
            </div>
        )
    }
}