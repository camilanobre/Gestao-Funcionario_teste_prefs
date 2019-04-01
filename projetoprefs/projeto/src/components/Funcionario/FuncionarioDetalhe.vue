<template>
  <div>
    <titulo :texto="`Funcionário: ${funcionario.nome}`" />
    
    <button class="btn btnEditar" @click="editar()">
        Editar
        </button>
        <div class="voltar"> 
        <button class="btn btnVoltar" @click="voltar()">Voltar</button>      
    </div>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Id:</td>
          <td>
              <label>{{funcionario.id}}</label>
              </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
              <label v-if="visualizando">{{funcionario.nome}}</label>
                 <input v-else v-model="funcionario.nome" type="text"/>

              </td>
        </tr>
        <tr>
          <td class="colPequeno">Idade:</td>
          <td>
              <label v-if="visualizando">{{funcionario.idade}}</label>
              <input v-else v-model="funcionario.idade" type="text"/>
              </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
              <label v-if="visualizando">{{funcionario.dataNascimento}}</label>
              <input v-else v-model="funcionario.dataNascimento" type="text"/>
              </td>
        </tr>
        <tr>
          <td class="colPequeno">Cargo:</td>
          <td>
              <label v-if="visualizando">{{funcionario.funcao}}</label>
              <input v-else v-model="funcionario.funcao" type="text"/>
              </td>
        </tr>
      </tbody>
    </table>

    <div style="margin:top: 10px">
        <div v-if="!visualizando" >
            <button class="btn btnSalvar" @click="salvar(funcionario)">Salvar</button>
            <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>

    </div>
</div>


  </div>
</template>

<script>
import Titulo from "../_share/Titulo";
export default {
  components: {
    Titulo
  },
  data() {
    return {
      funcionario: {},
      idFuncionario: this.$route.params.id,
      visualizando: true
    };
  },
  created() {
    this.$http
      .get("http://localhost:5000/api/funcionario/" + this.idFuncionario)
      .then(res => res.json())
      .then(funcionarios => (this.funcionario = funcionarios));
  },

  methods: {
                 voltar(){
               this.$router.back();
           }, 
      editar(){
          this.visualizando = !this.visualizando;
      },
      salvar(){
          let _funcionarioEditar = {
              id: this.funcionario.id,
              nome: this.funcionario.nome,
              idade: this.funcionario.idade,
              dataNascimento: this.funcionario.dataNascimento,
              funcao: this.funcionario.funcao
          }
            this.$http
        .put(`http://localhost:5000/api/funcionario/${_funcionarioEditar.id}`
        , _funcionarioEditar)
                  this.visualizando = !this.visualizando;

        },
      cancelar(){
          this.visualizando = !this.visualizando;
      },
  }
};
</script>

<style scoped>

.colPequeno {
    width: 20%;
    text-align: right;
    background-color: #4682B4 ;
    font-weight:lighter;
    color: white;
    font-family: Montserrat;
} 
.btnEditar{
    float:right;
    background-color: #1E90FF;
     width: 80px; 
     padding: 5px;
}
.btnVoltar{
    float:left;
    background-color: rgb(199, 199, 199);
     width: 80px;
     color:black;

}

.btnSalvar{
    float:right;
    background-color: rgb(79, 196, 68);
     width: 80px; 
     padding: 10px;
}
.btnCancelar{
    float:left;
    background-color: rgb(249, 186, 92);
     width: 90px; 
     padding: 10px;
    
}

input, select{
    margin: 0px;
    padding: 5px 10px;
    font-size: 0.9em;
    border: 1px solid silver;
    border-radius: 5px;
    font-family: Montserrat;
    width: 95%;
    background-color: rgb(245, 245, 245);
}
</style>