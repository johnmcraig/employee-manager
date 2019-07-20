<template>
    <b-container fluid>
        <b-row>
      <b-col
        md="2"
        offset-md="10">
        <router-link :to="{ name: 'EmployeeTable' }">Back to Table</router-link>
      </b-col>
    </b-row>

    <b-row>
      <b-col md="12">
        <b-form @submit.prevent="updateEmployee">
            <b-form-group
                id="input-group-1"
                label="Employee Name:"
                label-for="input-1">
                
                <b-form-input 
                    id="input-1"
                    v-model="formData.name"
                    type="text"
                    required
                    placeholder="Enter name">
                </b-form-input>
                
            </b-form-group>

            <b-form-group
                id="input-group-2"
                label="Employee Email:"
                label-for="input-2">
                
                <b-form-input 
                    id="input-2"
                    v-model="formData.email" 
                    type="text"
                    required
                    placeholder="Enter a valid email">
                </b-form-input>
                
            </b-form-group>

            <b-form-group
                id="input-group-3"
                label="Employee Position:"
                label-for="input-3">
                
                <b-form-input 
                    id="input-3"
                    v-model="formData.position" 
                    type="text"
                    
                    placeholder="Enter Employee Position">
                </b-form-input>
                
            </b-form-group>

            <b-form-group
                id="input-group-4"
                label="Employee Start Date:"
                label-for="input-4">
                
                <b-form-input 
                    id="input-4"
                    v-model="formData.startDate" 
                    type="date"
                    
                    placeholder="Enter a starting date">
                </b-form-input>
                
            </b-form-group>

            <b-col :md="5" offset="4">
                <b-button type="submit" variant="primary">Save</b-button>
                <b-button :to="{ name: 'EmployeeTable'}" variant="danger">Cancel</b-button>
            </b-col>

        </b-form>
      </b-col>
    </b-row>

    <b-modal
      ref="alertModal"
      :title="alertModalTitle"
      :ok-only="true"
      @ok="onAlertModalOkClick">
      <p class="my-4">{{ alertModalContent }}</p>
    </b-modal>

    </b-container>
</template>

<script>
import EmployeeService from '@/services/employee-service'

export default {
    name: 'EmployeeUpdate',
    data () {
        return {
            formData: {
                name: '',
                email: '',
                position: '',
                startDate: ''  
            },
            alertModalTitle: '',
            alertModalContent: '',
            isSuccessfull: false
        }
    },
    created() {
        EmployeeService.getSingle(this.$router.currentRoute.params.id).then((response) => {
            this.formData.name = response.data.name
            this.formData.email = response.data.email
            this.formData.position = response.data.position
            this.formData.startDate = response.data.startDate.splice('T')[0]
            
        })
    },
    methods: {
        updateEmployee () {
            EmployeeService.update(this.$router.currentRoute.params.id, this.formData).then(() => {
                this.isSuccessfull = true
                this.alertModalTitle = 'Success!'
                this.alertModalContent = 'Successfully Updated Employee'
                this.$refs.alertModal.show()
            }).catch((error) => {
                this.isSuccessfull = false
                this.alertModalTitle = 'Error'
                this.alertModalContent = error.response.data
                this.$refs.alertModal.show()
            })
        },
        onAlertModalOkClick () {
            if (this.isSuccessfull) {
                this.$router.push({ name: 'EmployeeTable' })
            }
        }
    }
}
</script>

<style scoped>
form {
    margin-bottom: 2rem;
    margin-top: 20px;
    min-height: 20px;
    padding: 19px;
    margin-bottom: 20px;
    background-color: #f5f5f5;
    border: 1px solid #e3e3e3;
    border-radius: 4px;
    box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
}

button {
    margin: 1rem;
}
</style>
