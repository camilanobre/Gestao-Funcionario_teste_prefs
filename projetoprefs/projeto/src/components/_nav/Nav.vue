<template>
    <div class="barraTop">
        <Nav class="margin-Principal"> 
        <router-link to="/home">Home</router-link>
            <router-link to="/funcionario">Funcionário</router-link>
                <router-link to="/sobre">Sobre</router-link>
        </Nav>

    </div>
</template>

<script>
    export default {
        
    }
</script>

<style scoped>
.barraTop{
}
nav{
    padding: 20px 20px 20px 0px
}

nav a{
    padding: 10px;
    text-decoration: none;
    /* background-color: ; */
    border-radius: 3px;
    color: black;
    font-weight: bolder;
    margin-right: 30px; 

}
nav .router-link-active{
    background-color:#1E90FF;
    color: white;

}
</style>