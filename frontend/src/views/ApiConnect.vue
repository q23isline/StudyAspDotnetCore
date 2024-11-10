<script setup lang="ts">
import { AppApi } from '@/api/AppApi'
import { ref, onMounted } from 'vue'

type ApiResponse = ProfileApiDataResponse[]

type ProfileApiDataResponse = {
  id: string
  firstName: string
  lastName: string
  firstNameKana: string
  lastNameKana: string
  sex: string
  birthDay: string
  cellPhoneNumber: string
  remarks: string
  createdAt: string
  lastUpdatedAt: string
}

const data = ref<ApiResponse>()
const loading = ref(true)
const error = ref<string | null>(null)

onMounted(async () => {
  try {
    const response = await AppApi.get<ApiResponse>('/api/profiles')
    data.value = response.data
  } catch (err) {
    error.value = (err as Error).message
  } finally {
    loading.value = false
  }
})
</script>

<template>
  <div>
    <h1>This is an api-connect page</h1>
    <div v-if="loading">Loading...</div>
    <div v-else-if="error">Error: {{ error }}</div>
    <div v-else>
      <ul>
        <li v-for="(profile, key) in data" :key="key">{{ profile.lastName }}</li>
      </ul>
    </div>
  </div>
</template>
