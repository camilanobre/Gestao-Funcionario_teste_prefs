<template>
  <div>
    <Titulo texto="Funcionario"/>
    <div>
      <input
        type="text"
        placeholder="Novo Funcionário"
        v-model="nome"
        @keyup.enter="addFuncionario()"
      >
      <button class="btn btnInput" @click="addFuncionario()">Enviar</button>
    </div>
    <table>
      <thead>
        <th class="colPequeno">Id</th>
        <th>Nome</th>
        <th>Ação</th>
        <!-- <th>Idade</th>
        <th>Data de Nascimento</th>
        <th>Função</th> -->
      </thead>
      <tbody v-if="funcionarios.length">
        <tr v-for="(funcionario, index) in funcionarios" :key="index">
          <td>{{funcionario.id}}</td>
          <router-link :to= "`/funcionarioDetalhe/${funcionario.id}`"
           tag="td" style="cursor: pointer">
              {{funcionario.nome}}
          </router-link>
          <!-- <td>{{funcionario.idade}}</td>
          <td>{{funcionario.dataNascimento}}</td>
          <td>{{funcionario.funcao}}</td> -->
          <td>
            <button class="btn" @click="remover(funcionario)">Remover</button>
         </td> 
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
       <td colspan="3" style="text-align:center"> 
         <h5>Nenhum funcionário foi encontrado</h5>
         </td>
        </tr>
      </tfoot>
    </table>
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
      titulo: "Funcionario",
      nome: "",
      // idade: "",
      // dataNascimento:"",
      // funcao: "",
      funcionarios: []
    };
  },
  created() {
    this.$http
      .get("http://localhost:5000/api/funcionario")
      .then(res => res.json())
      .then(funcionarios => (this.funcionarios = funcionarios));
    //  esse created usa a função Promise, usando a opção Vue Resource
  },
  props: {},
  methods: {
    addFuncionario() {
      let _funcionario = {
        nome: this.nome
      };

      this.$http
        .post("http://localhost:5000/api/funcionario", _funcionario)
        .then(res => res.json())
        .then(funcionarioRetornado => {
          this.funcionarios.push(funcionarioRetornado);
          this.nome = "";
        });
    },

    remover(funcionario) {
      this.$http
        .delete(`http://localhost:5000/api/funcionario/${funcionario.id}`)
        .then(() => {
          let indice = this.funcionarios.indexOf(funcionario);
          this.funcionarios.splice(indice, 1);
        });
    }
  }
};
</script>

<style scoped >
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}
.btnInput {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: #4169E1;
  display: inline;
}

.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
