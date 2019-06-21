<template>
  <b-container id="app">
    <b-row>
      <b-col>
        <navbar/>
      </b-col>
    </b-row>
    <b-row>
      <b-col>
        <router-view />
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import Navbar from '@/components/ui/Navbar'

export default {
  name: 'app',
  components: {
    Navbar
  }
}
</script>

<style>
</style>
