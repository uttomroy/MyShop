import React, { useState } from 'react';
import TextField from '@mui/material/TextField';
import { Box, 
    Button, 
    Checkbox, 
    FormControlLabel, 
    IconButton, 
    InputAdornment, 
    Link, 
    Stack } from '@mui/material';
import RemoveRedEyeIcon from '@mui/icons-material/RemoveRedEye';
import VisibilityOffIcon from '@mui/icons-material/VisibilityOff';


const Login = () => {
    const [showPassword, setShowPassword] = useState(false);

    return (
        <Box sx={{ maxWidth: '350px' }}>
            <Box sx={{ display: 'flex', flexDirection: 'column', gap: 3 }}>
                <TextField
                    fullWidth
                    autoComplete="username"
                    type="email"
                    label="Email Address"
                />
                <TextField
                    fullWidth
                    autoComplete="current-password"
                    type={showPassword ? "text" : "password"}
                    label="Password"
                    InputProps={{
                        endAdornment: (
                            <InputAdornment position="end">
                                <IconButton
                                    onClick={() => setShowPassword((prev) => !prev)}
                                >
                                    {showPassword ? (
                                        <RemoveRedEyeIcon />
                                    ) : (
                                        <VisibilityOffIcon />
                                    )}
                                </IconButton>
                            </InputAdornment>
                        ),
                    }}
                />
            </Box>
            <Box>
                <Stack
                    direction="row"
                    alignItems="center"
                    justifyContent="space-between"
                    sx={{ my: 2 }}
                >
                    <FormControlLabel
                        control={
                            <Checkbox
                                checked={true}
                            />
                        }
                        label="Remember me"
                    />

                    <Link href="#" underline="hover">
                        Forgot password?
                    </Link>
                </Stack>
            </Box>
            <Button fullWidth variant="contained">Submit</Button>
        </Box>
    );
};

export default Login;
