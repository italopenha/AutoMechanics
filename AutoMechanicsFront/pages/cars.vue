<template>
    <v-form ref="form" v-model="valid" lazy-validation>
        <v-text-field v-model="car.brand" :counter="10" :rules="brandRules" label="Marca" required></v-text-field>

        <v-text-field v-model="car.model" label="Modelo" required></v-text-field>

        <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
            Salvar
        </v-btn>

        <pre>{{car}}</pre>

    </v-form>
</template>

<script>
export default {
    data: () => ({
        valid: true,
        car: {
            brand: '',
            model: '',
        },
        brandRules: [
            v => !!v || 'Marca é obrigatório!',
            v => (v && v.length <= 10) || 'Marca não pode ter mais de 10 caracteres!',
        ],
        model: '',
        headers: [
            {
                text: 'Marca',
                align: 'start',
                sortable: false,
                value: 'brand',
            },
            { text: 'Modelo', value: 'model' },
        ],
    }),

    methods: {
        async submit() {

            debugger

            try {
                var response = await this.$axios({
                    method: 'POST',
                    url: 'https://localhost:7247/Car',
                    data: this.car,
                });

                debugger

            }
            catch { }
        },
    }
}
</script>

<style>

</style>