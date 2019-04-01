import Vue from 'vue';
import Router from 'vue-router';
import Funcionarios from './components/Funcionario/Funcionarios.vue';
import FuncionarioDetalhe from './components/Funcionario/FuncionarioDetalhe.vue';
import Home from './components/Home/Home.vue';
import Sobre from './components/Sobre/Sobre.vue';

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/',
            nome: 'Home',
            component: Home
         },
        {
            path: '/Home',
            nome: 'Home',
            component: Home
        },
        {
            path: '/funcionario',
            nome: 'Funcionario',
            component: Funcionarios
        },
        {
            path: '/funcionarioDetalhe/:id',
            nome: 'FuncionarioDetalhe',
            component: FuncionarioDetalhe
        },
        {
            path: '/sobre',
            nome: 'sobre',
            component: Sobre
        }
    ]
})