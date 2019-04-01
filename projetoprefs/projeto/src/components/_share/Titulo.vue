<template>
    <div>
        <div style="display: flex; width: 50%;">
            <h2>  {{texto}} </h2>
            

        </div>
        </div>
</template>

<script>
    export default {
        props: {
            texto : String
        },
        methods: {
 
        },
        
    }
</script>

<style scoped>
.voltar{
    width: 50%;
    position: absolute;
    margin-top: 15px;
}
</style>