from fastapi import APIRouter
import numpy as np

router = APIRouter()

@router.get('')
def hello_world() -> dict:
    return {'msg': 'Hello, World!'}

@router.get('/multiply')
async def matrix_multiply():
    a = np.random.rand(10, 10)
    b = np.random.rand(10, 10)
    result = np.dot(a, b)
    return {
        'matrix_a': a.tolist(),
        'matrix_b': b.tolist(),
        'result': result.tolist()
    }