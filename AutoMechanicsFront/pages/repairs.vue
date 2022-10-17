<template>
    <v-form ref="form" v-model="valid" lazy-validation>
        <v-text-field v-model="repair.mechanic" :counter="10" label="Mecânico" required></v-text-field>

        <v-text-field v-model="repair.description" label="Descrição" required></v-text-field>

        <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
            Salvar
        </v-btn>

        <pre>{{repair}}</pre>
    </v-form>
</template>

<script>
export default {
    data: () => ({
        valid: true,
        repair: {
            mechanic: '',
            description: '',
        },
        headers: [
            {
                text: 'Mecânico',
                align: 'start',
                sortable: false,
                value: 'mechanic',
            },
            { text: 'Descrição', value: 'description' },
        ],
    }),

    methods: {
        async submit() {

            debugger

            try {
                var response = await this.$axios({
                    method: 'POST',
                    url: 'https://localhost:7247/Repair',
                    data: this.repair,
                });

                debugger

            }
            catch { }
        }
    },
}
</script>

<style>

</style>