import { useState, useEffect } from 'react';
import { SanPham } from './types/product';
import './App.css';

function App() {
  const [products, setProducts] = useState<SanPham[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [dbContextEnum, setDbContextEnum] = useState<number>(2);

  useEffect(() => {
    fetchProducts();
  }, [dbContextEnum]);

  const fetchProducts = async () => {
    try {
      setLoading(true);
      setError(null);
      const response = await fetch(`http://localhost:5007/?dbContextEnum=${dbContextEnum}`);
      
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      
      const data: SanPham[] = await response.json();
      setProducts(data);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Có lỗi xảy ra khi tải dữ liệu');
      console.error('Error fetching products:', err);
    } finally {
      setLoading(false);
    }
  };

  const formatPrice = (price: number | null): string => {
    if (price === null) return 'N/A';
    return new Intl.NumberFormat('vi-VN', {
      style: 'currency',
      currency: 'VND'
    }).format(price);
  };

  const formatValue = (value: number | string | null): string => {
    if (value === null) return 'Null';
    return String(value);
  };

  return (
    <div className="app">
      <header className="app-header">
        <h1>Quản lý Sản phẩm - CSDLPT Tuần 6</h1>
        <div className="controls">
          <label htmlFor="dbContext">
            DB Context Enum:
            <select
              id="dbContext"
              value={dbContextEnum}
              onChange={(e) => setDbContextEnum(Number(e.target.value))}
              className="select-input"
            >
              <option value="0">Server1</option>
              <option value="1">Server2</option>
              <option value="2">Server3</option>
            </select>
          </label>
          <button onClick={fetchProducts} className="refresh-btn" disabled={loading}>
            {loading ? 'Đang tải...' : 'Làm mới'}
          </button>
        </div>
      </header>

      <main className="app-main">
        {loading && (
          <div className="loading">
            <div className="spinner"></div>
            <p>Đang tải dữ liệu...</p>
          </div>
        )}

        {error && (
          <div className="error">
            <h3>Lỗi!</h3>
            <p>{error}</p>
            <button onClick={fetchProducts} className="retry-btn">
              Thử lại
            </button>
          </div>
        )}

        {!loading && !error && (
          <>
            <div className="stats">
              <p>Tổng số sản phẩm: <strong>{products.length}</strong></p>
            </div>

            {products.length === 0 ? (
              <div className="empty-state">
                <p>Không có sản phẩm nào</p>
              </div>
            ) : (
              <div className="products-grid">
                {products.map((product, index) => (
                  <div key={index} className="product-card">
                    <div className="product-header">
                      <h3 className="product-name">
                        {formatValue(product.tenSanPham)}
                      </h3>
                      <span className="product-id">
                        ID: {formatValue(product.maSanPham)}
                      </span>
                    </div>
                    <div className="product-body">
                      <div className="product-info">
                        <div className="info-row">
                          <span className="info-label">Mã sản phẩm:</span>
                          <span className="info-value">{formatValue(product.maSanPham)}</span>
                        </div>
                        <div className="info-row">
                          <span className="info-label">Tên sản phẩm:</span>
                          <span className="info-value">{formatValue(product.tenSanPham)}</span>
                        </div>
                        <div className="info-row">
                          <span className="info-label">Giá bán:</span>
                          <span className="info-value price">{formatPrice(product.giaBan)}</span>
                        </div>
                        <div className="info-row">
                          <span className="info-label">Mã kho hàng:</span>
                          <span className="info-value">{formatValue(product.maKhoHang)}</span>
                        </div>
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            )}
          </>
        )}
      </main>
    </div>
  );
}

export default App;

