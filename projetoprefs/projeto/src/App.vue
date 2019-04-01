<template>
  <div id="app">
    <Nav></Nav>
    <div class="marginPrincipal">
      <router-view>
  <Funcionarios/>
  <Home/>
  <Sobre/>
      </router-view>
  </div>
  </div>
</template>

<script>
import Funcionarios from './components/Funcionario/Funcionarios.vue';
import Home from './components/Home/Home.vue';
import Sobre from './components/Sobre/Sobre.vue';
import Nav from './components/_nav/Nav';


export default {
  name: 'app',
  components: {
    Sobre,
    Funcionarios,
    Home,
    Nav
  }
}
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

body{
  background-color: #F8F8FF;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}
body, html {
  margin: 0;
  height: 100%;
}

.margin-Principal{
width: 50%;
margin: auto;
}

#app {
width: 50%;
}

.btn{
  background-color: #fa4430;
  border: 1px solid #000;
  padding: 10 px 20 px;
  cursor: pointer;
  color: white;
  font-weight: bold;
  font-size: 1em;
  border-radius: 5px;
  border-bottom: 3px solid black;
 
}
.btn:hover{
  text-shadow: 1px 1px 1px black;
  border-bottom: 2px solid;
  margin-top: 3px;
}


table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}
table tr td{
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}
table thead th{
  background-color: rgb(184, 208, 216) !important;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
}
.colPequeno {
  width: 5%;
}
</style>
