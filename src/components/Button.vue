<template>
    <button :class="$style.buttonPrimary">
      <slot></slot>
    </button>
  </template>
  
  <script>
  import styles from './Button.module.css';
  
  export default {
    name: 'PrimaryButton', // Changed to "PrimaryButton" to satisfy ESLint
    computed: {
      $style() {
        return styles;
      },
    },
  };
  </script>
  