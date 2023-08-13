const isDevelopmentMode =
  process.env.NODE_ENV !== 'production' 

const config = {
  isDevelopmentMode,
  baseUrl: isDevelopmentMode ? 'https://localhost:7034' : '',
}

export default config
